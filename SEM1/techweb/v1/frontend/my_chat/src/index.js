import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';


class Board extends React.Component {

  constructor(props) {
    super(props);
    this.state = {
      messages: [],
      messages2: [],
      value: '',
      user: true,
      current_user: 'User1'
    };
    this.handleChange = this.handleChange.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);
    this.switchUser = this.switchUser.bind(this);
  }

  handleChange(event) {
    this.setState({ value: event.target.value });
  }

  handleSubmit(event) {
    var joined
    if (this.state.user) {
      joined = this.state.messages.concat(this.state.value);
      event.preventDefault();
      this.setState({ messages: joined })
      this.setState({ value: '' })
    }
    else {
      joined = this.state.messages2.concat(this.state.value);
      event.preventDefault();
      this.setState({ messages2: joined })
      this.setState({ value: '' })
    }
    console.log(this.state.messages);
  }

  switchUser() {
    this.setState({ user: !this.state.user });
    //console.log(this.state.user);
  }

  render() {
    return (
      <div className="App">

        <header className="App-header">
          <h1>My Chat</h1>
        </header>

        <main className="App-main">
          <div className="App-msg">
            <div>
              {this.state.messages.map(function (message) {
                return <div key={message} className="user1">{"User1 : " + message}</div>
              }, this)}
            </div>
            <div>
              {this.state.messages2.map(function (message) {
                return <div key={message} className="user2">{message + " : User 2"}</div>
              }, this)}
            </div>
          </div>
          <form className="App-form" onSubmit={this.handleSubmit}>
            <input type="text" name="message" value={this.state.value} onChange={this.handleChange}></input>
            <input type="submit" value="send" ></input>
          </form>
            
            <button onClick={() => this.switchUser()}>Switch user</button>
        </main>

        <footer className="App-footer">
          <p>Welcome on the app my_chat 2020</p>
        </footer>

      </div>
    );
  }
}

ReactDOM.render(
  <Board />,
  document.getElementById('root')
);
