// @flow
import React from 'react';
import Input from './styles';

const SubmitInput = (props) => {
  const { inputValue, placeholder } = props;

  const handleOnChange = (e) => {
    props.handleChange(e.target.value);
  };

  return <Input onChange={handleOnChange} value={inputValue} placeholder={placeholder} />
};

export default SubmitInput;
