import React from 'react';
import { render } from 'react-dom';
import Home from './containers/home.jsx';
import { Router, Route, browserHistory } from 'react-router';

render((
  <Router history={browserHistory}>
    <Route path="/" component={Home} />
  </Router>), document.getElementById("app")
);
