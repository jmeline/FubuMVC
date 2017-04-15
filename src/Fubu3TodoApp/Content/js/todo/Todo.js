import React, { Component } from 'react';
import TodoInput from './TodoInput.js';
import TodoList from './TodoList.js';
import Notifications from './components/Notification.js';

import TodoBuilder from './TodoBuilder.js';

export default class Todo extends Component {
  constructor(props){
    super(props);
    this.state = {
      todoList: [],
      alert: false
    };
  }
  
  AddNewTodo = (e) => {
    if (e.key === 'Enter') {
      if (e.target.value.length > 0) {
        let newTodo = new TodoBuilder(e.target.value)
            .WithId()
            .WithTimeStamp();

        this.setState({
          todoList: [...this.state.todoList, newTodo],
          alert: true
        });
      }
    }
  }

  _newTaskNotification = () => {
    let todoList = this.state.todoList;
    let length = todoList.length;
    let lastAddedItem = todoList[length-1];
    if (lastAddedItem) {
      return `Added '${lastAddedItem.todo}'`;

    }
    return `Added '${lastAddedItem}'`;
  }

  render() {
    let todoList = this.state.todoList;
    return (
      <div>
        <TodoInput onKeyDown={this.AddNewTodo} />
        <TodoList todoList={this.state.todoList}/>
        <Notifications
          open={this.state.alert}
          message={this._newTaskNotification()}/>
      </div>
    );
  }
}