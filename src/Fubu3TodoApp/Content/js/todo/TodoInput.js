
import React from 'react';
import TextField from 'material-ui/TextField';
import { blue500, orange500 } from 'material-ui/TextField';

const styles = {
  floatingLabelStyle: {
    color: blue500
  },
  floatingLabelFocusStyle: {
    color: orange500
  }
};

export default class TodoInput extends React.Component {
  constructor(props){
    super(props);

    this.state = {
      textValue: ""
    };
  }

  static propTypes = {
    onChange: React.PropTypes.func
  };

  _handleTextFieldChange = (e) => {
    this.setState({
      textValue: e.target.value
    });
  }

  _handleSubmit = (e) => {
    e.preventDefault();
    this.setState({ textValue: '' });
  }

  render() {
    return (
      <form onSubmit={this._handleSubmit}>
        <TextField
          name="todo"
          value={this.state.textValue}
          onChange={this._handleTextFieldChange}
          floatingLabelText="Add a new task"
          floatingLabelStyle={styles.floatingLabelStyle}
          floatingLabelFocusStyle={styles.floatingLabelFocusStyle}
          {...this.props}
          />
      </form>
    );
  }
}
