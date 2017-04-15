import moment from 'moment';

export default class TodoBuilder {
  constructor(todo){
    this.todo = todo;
  }

  WithId(){
    const max = 100;
    const min = 1;
    this.id = Math.floor(Math.random() * (max - min) + min);
    return this;
  }

  WithTimeStamp(){
    this.timeStamp = moment().format('MMMM Do YYYY, h:mm:ss a');
    return this;
  }

}
