import React, { Component } from 'react';
import DatePicker from "react-datepicker";

import "react-datepicker/dist/react-datepicker.css";

export class Users extends Component {
  static displayName = Users.name;

  constructor(props) {
    super(props);
    this.state = { users: [], loading: true , newUsername: '', newDOB: new Date()};

    this.handleChangeName = this.handleChangeName.bind(this);
    this.handleChangeDOB = this.handleChangeDOB.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);
  }

  handleChangeName(event) {
    this.setState({newUsername: event.target.value});
  }

  handleChangeDOB(event){
    this.setState({newDOB: new Date(event)});
  }

  handleSubmit(event) {
    if(this.state.newUsername === null){
      alert('Filed Name must be filled' );
      return;  
    }

    const newUser = {name: this.state.newUsername, dateOfBirth: this.state.newDOB};

    const requestOptions = {
      method: 'POST',
      redirect: 'manual',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(newUser)
      };

    fetch('users/createUser', requestOptions);
    event.preventDefault();
    alert('Пользователь создан!') 
    this.setState({  newUsername: '', newDOB: new Date() });
    this.populateWeatherData();
  }

  componentDidMount() {
    this.populateWeatherData();
  }

  static renderUsersTable(users) {
    return (
      <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>Name</th>
            <th>DoB</th>
            <th>LastLoginDateTime</th>
          </tr>
        </thead>
        <tbody>
          {users.map(user =>
            <tr key={user.userId}>
              <td>{user.name}</td>
              <td>{user.dateOfBirth}</td>
              <td>{user.lastLoginDateTime}</td>
            </tr>
  )}
        </tbody>
      </table>
    );
  }

  render() {
    this.converUsersDateTimes();
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : Users.renderUsersTable(this.state.users);

    return (
      <div>
        <h1 id="tabelLabel" >USERS</h1>
        <p>All users from webapi DB.</p>
        {contents}
        <form onSubmit={this.handleSubmit}>
        <label>
          Name:
          <input type="text" value={this.state.newUsername} onChange={this.handleChangeName} />
        </label>
          <a></a>
          <p></p>
          <br></br>
          <DatePicker
          selected={this.state.newDOB}
          label="Controlled picker"
          onChange={this.handleChangeDOB} >
          </DatePicker>
          <a></a>
          <p></p>
          <br></br>
        <input type="submit" value="Submit" />
        </form>
      </div> 
    );
  }

  async populateWeatherData() {
    const response = await fetch('users');
    const data = await response.json();
    this.setState({ users: data, loading: false });
  }

  converUsersDateTimes(){
    this.state.users.forEach(x=>{
        x.dateOfBirth = new Date(x.dateOfBirth).toDateString();
        x.lastLoginDateTime = new Date(x.lastLoginDateTime).toDateString() + ' ' + new Date(x.lastLoginDateTime).toTimeString();
    });
  }
}
