import React, { Component } from 'react';
import { Route, Routes } from 'react-router-dom';
import AppRoutes from './AppRoutes';
import { Layout } from './components/Layout';
import './custom.css';

import {BrowserRouter as Router, Link} from 'react-router-dom';


export default class App extends Component {
  static displayName = App.name;

  render() {
    return (
      <><><div className='App'>
      </div><div>
        </div><Link to="/ingredients"><button></button></Link></>
        <div><Link to="/recipies"></Link></div></>
    );
  }
}
