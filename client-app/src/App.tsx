import React, { Component } from 'react';
import './App.css';
import axios from 'axios';
import 'semantic-ui-css/semantic.min.css'
import { Header, Icon, List } from 'semantic-ui-react';

class App extends Component {

  state = {
    values: []
  }

  componentDidMount() {
    axios.get('https://localhost:5001/WeatherForecast')
      .then((response) => {
        this.setState({
          values: response.data
        })
      })
  }

  render() {
    return (
      <div className="App">
        <div>
          {/* {cars.map((car) => (
            <CarItem car={car} />
          ))} */}
          <Header as="h2">
            <Icon name="users" />
            <Header.Content>Reactivities</Header.Content>
          </Header>
          <List>
            {this.state.values.map((value: any) => (

              <List.Item key={value.id}>
                <List.Icon name="github" verticalAlign="middle" size="big" />
                <List.Content>
                  <List.Header as="a">{value.name}</List.Header>
                  <List.Description as="a">This is the id of {value.name}: {value.id}</List.Description>
                </List.Content>
              </List.Item>
            ))}
          </List>
        </div>
      </div>
    );
  }
}

export default App;
