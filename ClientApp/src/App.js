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
import { UniversalChart } from './components/UniversalChart';


export default class App extends Component {
  static displayName = App.name;


  constructor(props) {
    super(props);
    let deviceTypes = [['Smartphones', 's'], ['Smartwatches', 'w'], ['Tablets', 't'], ['Cell phones', 'p']]
    .map(type => ({ label: type[0], value: type[1] }));
    this.state = { brands: [], deviceTypes: deviceTypes };

  }

  componentDidMount() {
    let deviceTypes = [['Smartphones', 's'], ['Smartwatches', 'w'], ['Tablets', 't'], ['Cell phones', 'p']]
      .map(type => ({ label: type[0], value: type[1] }));
    let query = 'api/DevicesData/GroupedBrands';
    console.log(query);
    fetch(query)
      .then(response => response.json())
      .then(brands => {
        var resultBrands = brands
          .map((b, index) => ({
            label: index == 0 ? 'Popular' : 'Rest', options: b
              .map(brand => ({ label: brand.name + " [" + brand.numberOfDevices + "]", value: brand.id }))
          }))
        this.setState({ brands: resultBrands });
        // this.setState({ brands: brands.map(brand => ({ label: brand.name + " [" + brand.numberOfDevices + "]", value: brand.id })) })
        console.log("result from brands");
        console.log(brands);
        console.log(deviceTypes);
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
          render={(routeProps) => <Phones {...routeProps} devices={this.state.deviceTypes} brands={this.state.brands} />}
        />
        <Route path='/minijack'
          render={(routeProps) => <MiniJackChart {...routeProps} devices={this.state.deviceTypes} brands={this.state.brands} />}
        />
        <Route path='/infrared'
          render={(routeProps) => <InfraredChart {...routeProps} devices={this.state.deviceTypes} brands={this.state.brands} />}
        />
        <Route path='/ram'
          render={(routeProps) => <RamChart {...routeProps} devices={this.state.deviceTypes} brands={this.state.brands} />}
        />
        <Route path='/charts'
          render={(routeProps) => <UniversalChart {...routeProps} devices={this.state.deviceTypes} brands={this.state.brands} />}
        />
      </Layout>
    );
  }
}
