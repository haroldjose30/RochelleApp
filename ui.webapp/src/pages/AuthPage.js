import AuthForm, { STATE_LOGIN } from '../components/AuthForm';
import React from 'react';
import { Card, Col, Row } from 'reactstrap';

class AuthPage extends React.Component {
  handleAuthState = authState => {
    if (authState === STATE_LOGIN) {
      this.props.history.push('/login');
    } else {
      this.props.history.push('/signup');
    }
  };

  handleLogoClick = () => {
    const url = 'http://www.rochellemassinhan.com.br';
    var win = window.open(url, '_blank');
    win.focus();
  };

  handleSubmit = authState => {
    if (authState === STATE_LOGIN) {
      this.props.history.push('/main');
    } else {
      this.props.history.push('/signuped');
    }
  };

  render() {
    return (
      <Row
        style={{
          height: '100vh',
          justifyContent: 'center',
          alignItems: 'center',
        }}>
        <Col md={6} lg={4}>
          <Card body>
            <AuthForm
              authState={this.props.authState}
              onChangeAuthState={this.handleAuthState}
              onLogoClick={this.handleLogoClick}
              onHandleSubmit={this.handleSubmit}
            />
          </Card>
        </Col>
      </Row>
    );
  }
}

export default AuthPage;
