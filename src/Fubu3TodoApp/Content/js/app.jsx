import React from 'react';
import { render } from 'react-dom';
import Home from './containers/home.jsx';
// import Todo from './containers/todo.jsx';
import { Router, Route, browserHistory } from 'react-router';

render((
  <Router history={browserHistory}>
    <Route path="/" component={Home}>
      <IndexRoute component={Home} />
      {/* <Route path='todo' component={Todo} /> */}
    </Route>

  </Router>), document.getElementById("app")
);
