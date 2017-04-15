import React from 'react';
import Todo from './Todo.js';
import TodoHeader from './TodoHeader.js';

export default class TodoApp extends React.Component {
  render() {
    return (
      <div>
        <TodoHeader />
        <div className="App-intro">
          <Todo />
        </div>
      </div>
    );
  }
}
