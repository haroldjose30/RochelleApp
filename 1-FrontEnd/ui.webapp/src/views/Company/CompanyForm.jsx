import React from 'react';
import PropTypes from 'prop-types';

import {
  Col,
  Card,
  CardHeader,
  CardBody,
  Button,
  Form,
  FormGroup,
  Label,
  Input,
  FormText,
  FormFeedback,
} from 'reactstrap';


import Page from '../../components/Page';
import Company from '../../models/Company';
import ModalConfirm from '../Modal/ModalConfirm';


const CompanyForm = props => {

  return (
    <Page 
      title="Empresa"
      loading={props.loading}
      alertMessage={props.alertMessage}>
     
        <Col xl={6} lg={12} md={12}>
          <Card>
            <CardHeader>{props.cardHeader}</CardHeader>
            <CardBody>
            <Form onSubmit={props.onHandleSubmit} autoComplete="off">

                <FormGroup>
                  <Label for="companyName">Razão Social</Label>
                  <Input type="text" 
                          name="companyName" 
                          id="companyName" 
                          value={props.item.companyName}
                          valid={props.validations.companyName.isValid}
                          invalid={props.validations.companyName.isInvalid}
                          onChange={props.onHandleInputChange}/>
                  <FormFeedback>
                    {props.validations.companyName.message}
                  </FormFeedback>
                </FormGroup>

                <FormGroup>
                  <Label for="fantasyName">Nome Fantasia</Label>
                  <Input  type="text" 
                          name="fantasyName" 
                          id="fantasyName" 
                          value={props.item.fantasyName}
                          valid={props.validations.fantasyName.isValid}
                          invalid={props.validations.fantasyName.isInvalid}
                          onChange={props.onHandleInputChange}/>
                  <FormFeedback>
                    {props.validations.fantasyName.message}
                  </FormFeedback>
                </FormGroup>

                <FormGroup>
                  <Label for="corporateNumber">CPF / CNPJ</Label>
                  <Input  type="text" 
                          name="corporateNumber" 
                          id="corporateNumber"  
                          value={props.item.corporateNumber}
                          valid={props.validations.corporateNumber.isValid}
                          invalid={props.validations.corporateNumber.isInvalid}
                          onChange={props.onHandleInputChange}/>
                  <FormFeedback>
                    {props.validations.corporateNumber.message}
                  </FormFeedback>
                  <FormText>Informe apenas número, sem ponto ou barras.</FormText>
                </FormGroup>

                <div>
                  <Button type="submit" outline color="primary">Gravar</Button>{' '}
                  <Button outline color="danger" onClick={props.onHandleDelete}>Excluir</Button>{' '}
                  <Button outline color="info" onClick={props.onHandleBack}>Voltar</Button>
                 </div>

              </Form>
              
            </CardBody>
          </Card>
        </Col>

       <ModalConfirm 
              isOpen={props.modalState} 
              title={`Confirma excluir ${props.item.companyName}`}
              onToggle={props.onModalStateChange}
              sucess='Não'
              danger='Sim Excluir'
              onModalClick={props.onModalClick}
              />

    </Page>
  );
};

CompanyForm.propTypes = {
  cardHeader: PropTypes.string,
  onHandleSubmit: PropTypes.func,
  onHandleBack: PropTypes.func,
  onHandleDelete :PropTypes.func,
  onHandleInputChange: PropTypes.func, 
  validations:PropTypes.object,
  item:PropTypes.object,
  modalState:PropTypes.bool,
  primaryHidden:PropTypes.bool,
  onModalStateChange:PropTypes.func, 
  onModalClick:PropTypes.func, 
  loading:PropTypes.bool,
};

CompanyForm.defaultProps = {
  cardHeader: '',
  onHandleSubmit: () => {},
  onHandleBack: () => {},
  onHandleDelete: () => {},
  onHandleInputChange: () => {},
  item: new Company(),
  modalState:false,
  onModalStateChange:() => {},
  onModalClick:() => {},
  loading:false,
};

export default CompanyForm;
