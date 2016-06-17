import React from 'react';
import Nav from 'react-bootstrap/lib/Nav';
import Navbar from 'react-bootstrap/lib/Navbar';
import NavItem from 'react-bootstrap/lib/NavItem';
import { Link } from 'react-router';

export default class Navigation extends React.Component {
  constructor(props) {
    super(props);
  }

  render() {
    return (
      <div className="navbarTheme navbarFixedTop">
        <ul>
          <li> <Link to="/">TW-TODO</Link> </li>
          <li> <Link to="/todo">Todo</Link> </li>
        </ul>
      </div>
    );
  }
}
