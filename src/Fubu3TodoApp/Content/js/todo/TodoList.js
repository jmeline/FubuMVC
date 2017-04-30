import React from 'react';
import Subheader from 'material-ui/Subheader';
import Drawer from 'material-ui/Drawer';
import TodoEdit from './TodoEdit.js';
import TodoTable from './TodoTable.js';

export default class TodoList extends React.Component {
  constructor(props){
    super(props);
    this.state = {
      open: false,
      selected: {
        todo: null,
        id: null,
        timeStamp: null
      }
    };
  }

  _handleDrawerOpen = (x) => {
    console.log(x, this.state.open);
    this.setState({ 
      open: !this.setState.open,
      selected: x
     });
  };

  render() {
    return (
      <div>
        <TodoTable
          data={this.props.todoList}
          onTouchTap={this._handleDrawerOpen}/>
        <Drawer
          docked={false}
          width={350}
          open={this.state.open}
          onRequestChange={(open) => this.setState({open})}>
          <TodoEdit model={this.state.selected}/>
        </Drawer>
      </div>
    );
  }
}
