import React from 'react';
import { render } from 'react-dom';
import Home from './containers/home.jsx';

require('font-awesome/css/font-awesome.min.css');

const rootElement = document.getElementById("app");

rootElement.innerHTML = '<i class="fa fa-twitter"></i>';

render(
  <Home />,
  rootElement
);
