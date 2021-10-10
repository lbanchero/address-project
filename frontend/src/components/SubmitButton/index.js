// @flow
import React from 'react';
import Button from './styles';

const SubmitButton = (props) => {
  const { handleSubmit, text } = props;

  return (
    <Button onClick={handleSubmit}>{text}</Button>
  );
};

export default SubmitButton;
