const app = require('../src/index')
const chai = require('chai')
const chaiHttp = require('chai-http')

chai.use(chaiHttp)

let client

describe('User REST API', () => {

  before(() => {
    client = require('../src/dbClient')
  })
  
  after(()=> {
    app.close()
    client.quit()
  })

  describe('POST /user', () => {

    it('create a new user', (done) => {
      const user = {
        username: 'theotarbe',
        firstname: 'Theo',
        lastname: 'Tarbe'
      }
      chai.request(app)
        .post('/user')
        .send(user)
        .then((res) => {
          chai.expect(res).to.have.status(201)
          chai.expect(res.body.status).to.equal('success')
          chai.expect(res).to.be.json
          done()
        })
        .catch((err) => {
           throw err
        })
    })
    
    it('pass wrong user parameters', (done) => {
      const user = {
        firstname: 'theo',
        lastname: 'tarbe'
      }
      chai.request(app)
        .post('/user')
        .send(user)
        .then((res) => {
          chai.expect(res).to.have.status(400)
          chai.expect(res.body.status).to.equal('error')
          chai.expect(res).to.be.json
          done()
        })
        .catch((err) => {
           throw err
        })
    })
  })

  describe('GET /user', ()=> {
     //TODO Create test for the get method
     it.skip('successfully get a user by username', (done) => {
      const user = {
        username: 'theotarbe',
        firstname: 'theo',
        lastname: 'tarbe'
      }
      chai.request(app)
        .get('/user')
        .send(user)
        .then((res) => {
          chai.expect(res).to.have.status(201)
          chai.expect(res.body.status).to.equal('success')
          chai.expect(res).to.be.json
          done()
        })
        .catch((err) => {
           throw err
        })
    })
  })
})
