import React from 'react';

import { Navbar, Nav, NavItem } from 'reactstrap';

import SourceLink from '../SourceLink';

const Footer = () => {
  return (
    <Navbar>
      <Nav navbar>
        <NavItem>
          2019 Rochelle App, desenvolvido por <SourceLink href="http://haroldjose.azurewebsites.net">Harold josé</SourceLink>
        </NavItem>
      </Nav>
    </Navbar>
  );
};

export default Footer;
