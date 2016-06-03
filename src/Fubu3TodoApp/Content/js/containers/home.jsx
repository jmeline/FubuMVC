import React from 'react';
import Navigation from '../components/navigation.jsx';

export default class Home extends React.Component {
  constructor(props) {
    super(props);
  }

  render() {
    return (
      <div>
        <Navigation />
        Home
      </div>
    );
  }
}
