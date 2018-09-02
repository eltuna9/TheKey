import React, {Component} from 'react';
import {Home} from './components/home/home';
import './styles/commons.scss';

export default class App extends Component {
  displayName = App.name;

  render() {
    return <Home />;
  }
}
