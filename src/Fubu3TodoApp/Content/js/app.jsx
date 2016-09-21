import React from 'react';
import { render } from 'react-dom';
import Home from './containers/home.jsx';
import Todo from './components/todo.jsx';
import { Router, Route, browserHistory, IndexRoute} from 'react-router';

render((
  <Router>
    <Route path="/" component={Home}>
      <IndexRoute component={Home} />
      <Route path='todo' component={Todo} />
    </Route>
  </Router>), document.getElementById("app")
);
