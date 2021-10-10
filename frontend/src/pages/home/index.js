import React, { useEffect, useState } from 'react';
import {
  Container,
  Title,
  ControlsContainer,
  DescriptionTitle,
  Description,
  AddressInfoContainer
} from './styles';
import UserTable from '../../components/UserTable';
import SubmitInput from '../../components/SubmitInput';
import SubmitButton from '../../components/SubmitButton';
import AddressService from '../../services/address';
import UserService from '../../services/user';

const HomeContainer = () => {
  const [users, setUsers] = useState();
  const [addressInput, setAddressInput] = useState();
  const [usernameInput, setUsernameInput] = useState();
  const [checkedAddress, setCheckedAddress] = useState();

  useEffect(() => {
    getUsers();
  }, []);

  const getUsers = () => {
    UserService.getUsers().then((response) => {
      response.json().then((responseJson) => {
        setUsers(responseJson);
      });
    })
  }

  const handleAddress = (addressInputValue) => {
    setAddressInput(addressInputValue);
  };

  const handleUsername = (usernameInputValue) => {
    setUsernameInput(usernameInputValue);
  };

  const handleAddressSubmit = () => {
    if (addressInput && addressInput !== '') {
      AddressService.checkAddress({ street: addressInput })
      .then((response) => {
        response.json().then((responseJson) => {
          setCheckedAddress(responseJson);
          setAddressInput('');
        });
      })
      .catch(() => {
        alert("Search returned 0 results");
      })
    }
  };

  const handleUserSubmit = () => {
    if (usernameInput && usernameInput !== '') {
      UserService.createUser({
        fullName: usernameInput,
        address: {
          street: checkedAddress.street,
          latitude: checkedAddress.latitude,
          longitude: checkedAddress.longitude,
        }
      }).then((response) => {
        response.json().then((responseJson) => {
          setCheckedAddress(responseJson);
          setUsernameInput('');
          setCheckedAddress(null);

          getUsers();
        });
      })
    }
  };

  const showCheckedAddressInformation = () => {
    if (checkedAddress && checkedAddress.street !== '') {
      return (
        <AddressInfoContainer>
          <DescriptionTitle>Address coordinates found</DescriptionTitle>
          <Description>{checkedAddress.street}</Description>
          <Description>{`${checkedAddress.latitude}, ${checkedAddress.longitude}`}</Description>
        </AddressInfoContainer>
      )
    }
  };

  const showAddressControls = () => {
    if (!checkedAddress) {
      return (
        <div>
          <SubmitInput inputValue={addressInput} handleChange={handleAddress} placeholder={"Insert your address"}/>
          <SubmitButton text={"Check"} handleSubmit={handleAddressSubmit} />
        </div>
      )
    }
  };

  const showUsersControls = () => {
    if (checkedAddress && checkedAddress.street !== '') {
      return (
        <div>
          <SubmitInput inputValue={usernameInput} handleChange={handleUsername} placeholder={"Insert user name"}/>
          <SubmitButton text={"Add to list"} handleSubmit={handleUserSubmit} />
        </div>
      )
    }
  };

  return (
    <Container>
      <Title>User coordinates app</Title>
      <ControlsContainer>
        {showAddressControls()}
      </ControlsContainer>
      <ControlsContainer>
        {showCheckedAddressInformation()}
      </ControlsContainer>
      <ControlsContainer>
        {showUsersControls()}
      </ControlsContainer>
      <UserTable users={users} />
    </Container>
  );
};

export default HomeContainer;
