import React from 'react';
import {
  Table, TableBody, TableHeader,
  TableHeaderColumn, TableRow, TableRowColumn
} from 'material-ui/Table';
import IconButton from 'material-ui/IconButton';
import ModeEdit from 'material-ui/svg-icons/editor/mode-edit';


export default class TodoTable extends React.Component {

  constructor(props){
    super(props);
    this.state = {
      showCheckboxes: true
    };
  }

  createList = () => {
    return this.props.data.map((x,i) =>
      <TableRow key={`${x}${i}`}>
        <TableRowColumn>{x.todo}</TableRowColumn>
        <TableRowColumn>{x.timeStamp}</TableRowColumn>
        <TableRowColumn>
          <IconButton onTouchTap={() => this.props.onTouchTap(x)}>
            <ModeEdit />
          </IconButton>
        </TableRowColumn>
      </TableRow>
    );
  };

  render() {
    const todoList = this.createList();
    return (
      <Table
        multiSelectable={false}
        selectable={false}>
        <TableHeader
          displayRowCheckbox={false}
          displaySelectAll={false}
          adjustForCheckbox={false}
          enableSelectAll={false}>
          <TableRow>
            <TableHeaderColumn>Name</TableHeaderColumn>
            <TableHeaderColumn>Created</TableHeaderColumn>
          </TableRow>
        </TableHeader>
        <TableBody
          adjustForCheckbox={false}
          displayRowCheckbox={false}>
          {todoList}
        </TableBody>
      </Table>
    );
  }
}
