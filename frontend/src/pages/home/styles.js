import styled from 'styled-components';

export const Container = styled.div`
  display: flex;
  flex-direction: column;
  flex-wrap: nowrap;
  align-content: stretch;
  height: 100%;
  margin-top: 40px;
`;

export const Title = styled.label`
  font-size: 24px;
  color: #000;
  font-family: 'PT Sans', sans-serif;
  align-self: center;
  margin-top: 23px;
`;

export const DescriptionTitle = styled.label`
  font-size: 20px;
  color: #444444;
  font-family: 'PT Sans', sans-serif;
  align-self: center;
`;

export const Description = styled.label`
  font-size: 16px;
  color: #999999;
  font-family: 'PT Sans', sans-serif;
  align-self: center;
`;

export const ControlsContainer = styled.div`
  display: flex;
  flex-flow: row wrap;
  justify-content: center;
  min-height:35px;
`;

export const AddressInfoContainer = styled.div`
  display: flex;
  flex-flow: column;
  justify-content: center;
`;
