import React from 'react';
import Navigation from '../components/navigation.jsx';
import HomePage from '../components/homePage.jsx';

export default class Home extends React.Component {
  constructor(props) {
    super(props);
  }

  render() {
    return (
      <div className="mainTheme">
        <Navigation />
        <HomePage />
        <HomePage />
        <a href="#" > stuff </a>
</div>
    );
  }
}
