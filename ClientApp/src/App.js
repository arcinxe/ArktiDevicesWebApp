import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';
import { Counter } from './components/Counter';
import { Phones } from './components/Phones';
// import { TestPage } from './components/TestPage';
import { MiniJackChart } from './components/MiniJackChart';
import { InfraredChart } from './components/InfraredChart';
import { RamChart } from './components/RamChart';


export default class App extends Component {
  static displayName = App.name;

  render() {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/counter' component={Counter} />
        <Route path='/fetch-data' component={FetchData} />
        <Route path='/devices' component={Phones} />
        <Route path='/minijack' component={MiniJackChart} />
        <Route path='/infrared' component={InfraredChart} />
        <Route path='/ram' component={RamChart} />
      </Layout>
    );
  }
}
