
import React, { Component } from 'react';
//import PropTypes from 'prop-types';

function wrapState(ComposedComponent) {
  return class SelectableList extends Component {
    /*static PropTypes = {
      children: PropTypes.node.isRequired,
      defaultValue: PropTypes.number.isRequired,
    };
    */

    componentWillMount() {
      this.setState({
        selectedIndex: this.props.defaultValue,
      });
    }

    _handelRequestChange = (e, index) => {
      this.setState({
        selectedIndex: index,
      });
    };

    render() {
      return (
        <ComposedComponent
          value={this.state.selectedIndex}
          onChange={this._handelRequestChange}>
          {this.props.children}
        </ComposedComponent>

      );
    }
  }
}
export default wrapState;
