import styled from 'styled-components';

export const Container = styled.div`
  display: flex;
  flex-direction: column;
  flex-wrap: nowrap;
  justify-content: center;
  align-items: center;
`;

export const Table = styled.table`
  border-collapse: collapse;
  margin: 20px 0;
  font-size: 16px;
  font-family: 'PT Sans', sans-serif;
  width: 700px;
  box-shadow: 0 0 20px rgba(0, 0, 0, 0.15);
`;

export const TableHeader = styled.thead`
  background-color: #283747;
  color: #ffffff;
  text-align: center;
  border-radius:10px
  `;

export const TableBody = styled.tbody`
  color: #283747;
  text-align: center;
`;

export const TableColumn = styled.td`
  padding: 3px;
`;

export const TableRow = styled.tr`
border: 1px solid lightgray;
`;

export const CheckBox = styled.input`
  cursor:pointer;
`;
