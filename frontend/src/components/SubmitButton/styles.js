import styled from 'styled-components';

const Button = styled.button`
  background-color:#0E81EA;
  border-radius:3px;
  border:0px;
  display:inline-block;
  cursor:pointer;
  color:#ffffff;
  font-family: 'PT Sans', sans-serif;
  font-size:20px;
  text-shadow:0px -1px 1px #5b6178;
  outline: none;
  width: 100px;
  height: 35px;
  margin: 7px 15px 7px 15px;

  &:hover {
    background:linear-gradient(to bottom, #407294 5%, #2C4F67 100%);
    background-color:#407294;
  }

  &:active {
    position:relative;
    top:1px;
  }
`;

export default Button;
