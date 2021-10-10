import React from 'react';
import {
  Container,
  Table,
  TableHeader,
  TableRow,
  TableColumn,
  TableBody,
} from './styles';

const UserTable = (props) => {
  const { users } = props;

  const renderData = () => {
    if (users && users.length > 0) {
      return users.map((item, index) => (
        <TableRow key={index}>
          <TableColumn>{item.fullName}</TableColumn>
          <TableColumn>{item.address.street}</TableColumn>
          <TableColumn>{`${item.address.latitude}, ${item.address.longitude}`}</TableColumn>
        </TableRow>
      ));
    }

    return (
      <tr key={1}>
        <td colSpan={3}>Users list is empty</td>
      </tr>
    );
  };

  return (
    <Container>
      <Table>
        <TableHeader>
          <TableRow>
            <TableColumn>Name</TableColumn>
            <TableColumn>Address</TableColumn>
            <TableColumn>Lat/Lon</TableColumn>
          </TableRow>
        </TableHeader>
        <TableBody>
          {renderData()}
        </TableBody>
      </Table>
    </Container>
  );
};
export default UserTable;
