import React, { Component } from 'react';
import getMuiTheme from 'material-ui/styles/getMuiTheme';
import MuiThemeProvider from 'material-ui/styles/MuiThemeProvider';

import TodoApp from './todo/TodoApp.js';
import '../App.css';

const darkMuiTheme = getMuiTheme();

class App extends Component {

  render() {
    return (
      <MuiThemeProvider
        muiTheme={darkMuiTheme}>
        <div className="App">
          <TodoApp />
        </div>
      </MuiThemeProvider>
    );
  }
}

export default App;
