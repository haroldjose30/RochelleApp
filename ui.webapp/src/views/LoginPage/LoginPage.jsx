import React from "react";
import { Card, CardHeader, CardBody, CardTitle, Row, Col } from "reactstrap";

import FormInputs from "../../components/FormInputs/FormInputs.jsx";
import Button from "../../components/CustomButton/CustomButton.jsx";


class Login extends React.Component {
  render() {
    return (
      <div className="content">
        <Row>
          <Col md={8} xs={12}>
            <Card className="card-user">
              <CardHeader>
                <CardTitle>Login</CardTitle>
              </CardHeader>
              <CardBody>
                <form>
                  
                <FormInputs
                    ncols={["col-md-12"]}
                    proprieties={[
                      {
                        label: "E-mail",
                        inputProps: {
                          type: "email",
                          placeholder: "suporte@rochelleapp.com.br"
                        }
                      }
                    ]}
                  />


                  <FormInputs
                  ncols={["col-md-12"]}
                  proprieties={[
                    {
                      label: "Senha",
                      inputProps: {
                        type: "password",
                        placeholder: "informe a senha"
                      }
                    }
                  ]}
                />                 

                  <Row>
                    <div className="update ml-auto mr-auto">
                      <Button color="primary" round>Entrar</Button>
                    </div>
                  </Row>
                </form>
              </CardBody>
            </Card>
          </Col>
        </Row>
      </div>
    );
  }
}

export default Login;
