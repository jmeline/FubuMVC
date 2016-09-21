import React from 'react';
import request from 'superagent';

export default class Todo extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      data: ""
    };
  }

  componentWillMount() {
    console.log('Todo: componentWillMount');
    // this.getValues().then(data => {
    //   console.log('success! ' + data);
    // });
  }

  getValues() {
    return new Promise((resolve, reject) => {
      request
        .get('todo/')
        .set('Accept', 'application/json')
        .end((err, resp) => {
          if (err) {
            reject(err);
          }
          console.log('in promse' + resp);
          resolve(resp.body);
        })
    })
  }

  render() {
    return (
      <div> Todo!! </div>
    );
  }
}
