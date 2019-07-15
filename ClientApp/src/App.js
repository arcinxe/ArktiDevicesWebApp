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


  constructor(props) {
    super(props);
    this.state = { brands: [] };

  }

  componentDidMount() {
    let query = 'api/PhonesData/Brands';
    console.log(query);
    fetch(query)
      .then(response => response.json())
      .then(brands => {
        this.setState({ brands: brands.map(brand => ({ label: brand.name + " [" + brand.numberOfDevices + "]", value: brand.id })) })
        console.log("result from brands");
        console.log(brands);
      });

  }


  render() {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/counter' component={Counter} />
        <Route path='/fetch-data' component={FetchData} />
        <Route
          path='/devices'
          render={(routeProps) => <Phones {...routeProps} brands={this.state.brands} />}
        />
        <Route path='/minijack'  
          render={(routeProps) => <MiniJackChart {...routeProps} brands={this.state.brands} />}
        />
        <Route path='/infrared'
          render={(routeProps) => <InfraredChart {...routeProps} brands={this.state.brands} />}
        />
        <Route path='/ram' 
          render={(routeProps) => <RamChart {...routeProps} brands={this.state.brands} />}
        />
      </Layout>
    );
  }
}
