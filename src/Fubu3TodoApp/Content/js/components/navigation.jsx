import React from 'react';
import Nav from 'react-bootstrap/lib/Nav';
import Navbar from 'react-bootstrap/lib/Navbar';
import NavItem from 'react-bootstrap/lib/NavItem';

export default class Navigation extends React.Component {
  constructor(props) {
    super(props);
  }

  render() {
    return (
      <Navbar inverse>
        <Navbar.Header>
          <Navbar.Brand>
            <a href="#">TW-TODO</a>
          </Navbar.Brand>
        </Navbar.Header>
        <Nav>
          <NavItem href="#"> Link1 </NavItem>
          <NavItem href="#"> Link2 </NavItem>
        </Nav>
      </Navbar>
    );
  }
}
