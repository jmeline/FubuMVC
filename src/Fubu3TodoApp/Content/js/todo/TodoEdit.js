import React from 'react';

export default class TodoEdit extends React.Component {
  constructor(props){
    super(props);
  }

  render() {
    var model = this.props.model;
    return (
      <div>
        <h1> id: {model.id} </h1>
        <h1> todo: {model.todo} </h1>
        <h1> timeStamp: {model.timeStamp} </h1>
      </div>
      );
    }
}
