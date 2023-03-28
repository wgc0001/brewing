import React from "react";
import HomePage from './components';
import {BrowserRouter as Router, Switch, Route} from 'react-router-dom';

function App() {
  return (
    <Router>
      <Switch>
        <Route exact path ="/" component = {HomePage}/>
      </Switch>
    </Router>
  );
}
