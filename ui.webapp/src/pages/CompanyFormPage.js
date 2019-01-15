import React from 'react';

import {
  Row,
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

import Page from '../components/Page';

const CompanyFormPage = () => {
  return (
    <Page title="Empresa" breadcrumbs={[{ name: 'Cadastros', active: false },{ name: 'Empresa', active: true }]}>
     
      <Row>
        <Col xl={6} lg={12} md={12}>
          <Card>
            <CardHeader>Incluir</CardHeader>
            <CardBody>
              <Form>
                <FormGroup>
                  <Label for="name">Nome</Label>
                  <Input  valid={false} invalid={false}/>
                  <FormFeedback>
                    Nome inválido
                  </FormFeedback>
                  <FormText>Informe o nome da empresa.</FormText>
                </FormGroup>
                <FormGroup>
                  <Label for="address">Endereço</Label>
                  <Input  valid={false} invalid={true}/>
                  <FormFeedback>
                    Endereço inválido
                  </FormFeedback>
                  <FormText>informe o endereço da empresa.</FormText>
                </FormGroup>
              </Form>
            </CardBody>
          </Card>
        </Col>
      </Row>
    </Page>
  );
};

export default CompanyFormPage;
