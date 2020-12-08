const client = require('../dbClient')

module.exports = {
  create: (user, callback) => {
    // Check parameters
    if(!user.username)
      return callback(new Error("Wrong user parameters"), null)
    // Create User schema
    const userObj = {
      firstname: user.firstname,
      lastname: user.lastname,
    }
    // Save to DB
    // TODO check if user already exists
    client.hmget(user.username, "firstname", "lastname", (err, res) => {
      if (res) return callback(new Error("Already existing user"), null)
      client.hmset(user.username, userObj, (err2, res2) => {
        if (err2) return callback(err2, null)
        callback(null, res2) // Return callback
      })
    })
    
  },
  get: (username, callback) => {
    // TODO create this method : Successful get user
    client.hmget(username, "firstname", "lastname", (err, res) => {
      if (err) return callback(err,null)
      callback(null,res) // Return callback
    })
  }
}
