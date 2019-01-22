import Page from '../../components/Page';
import React from 'react';
import { Card, CardBody, CardHeader,Table,Button } from 'reactstrap';
import PropTypes from 'prop-types';



const CompanyList = props => {
   
  return (    
   
    <Page
      title="Empresa"
      className="CompanyList"
      alertMessage={props.alertMessage}>
        <Card className="mb-3">
        <CardHeader>
            <Button outline color="primary" onClick={() => props.onHandleNewClick()}>Incluir</Button>
        </CardHeader>
        <CardBody>
            <Table size="sm" striped>
            <thead>
                <tr>
                    <th>Razão Social</th>
                    <th>Nome Fantasia</th>
                    <th>CPF/CNPJ</th>
                    <th>Ação</th>
                </tr>
            </thead>
            <tbody >
                {props.list.map((item) => (
                    <tr key={item.id}>
                        <td>{item.companyName}</td>
                        <td>{item.fantasyName}</td>
                        <td>{item.corporateNumber}</td>
                        <td><Button outline color="primary" onClick={() => props.onHandleEditClick(item)}>Editar</Button></td>
                    </tr>
                ))}
            </tbody>
            </Table>
        </CardBody>
        </Card>
       
    </Page>
  );
}

  CompanyList.propTypes = {
    onHandleEditClick: PropTypes.func,
    onHandleNewClick: PropTypes.func,
    list:PropTypes.array,
    alertMessage:PropTypes.string,
  };
  
  CompanyList.defaultProps = {
    onHandleEditClick: () => {},
    onHandleNewClick: () => {},
    list: [],
    alertMessage:''
  };

export default CompanyList;
