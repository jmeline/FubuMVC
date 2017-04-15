import React from 'react';
import Snackbar from 'material-ui/Snackbar';

export default class Notifications extends React.Component {
  static propTypes = {

  };

  constructor(props) {
    super(props);
    this.state = {
      open: false
    };
  }

  render() {
    return (
      <Snackbar
        autoHideDuration={2000}
        {...this.props} />
    );
  }
}
