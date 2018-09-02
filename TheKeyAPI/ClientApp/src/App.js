import React, {Component} from 'react';
import {Layout} from './components/home/home';
import './styles/commons.scss';

export default class App extends Component {
  displayName = App.name;

  render() {
    return <Layout>I am the layout</Layout>;
  }
}
