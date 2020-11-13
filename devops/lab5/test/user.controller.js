const { expect } = require('chai')
const userController = require('../src/controllers/user')

let client

describe('User Test New branch 2nd change', () => {

  before(()=>{
    client = require('../src/dbClient')
  })

  beforeEach(()=>{
    //console.log('before each test')
    client.flushall()
  })

  describe('Create', () => {

    it('create a new user', (done) => {
      const user = {
        username: 'theotarbe',
        firstname: 'theo',
        lastname: 'tarbe'
      }
      userController.create(user, (err, result) => {
        expect(err).to.be.equal(null)
        expect(result).to.be.equal('OK')
        done()
      })
    })

    it('passing wrong user parameters', (done) => {
      const user = {
        firstname: 'theo',
        lastname: 'tarbe'
      }
      userController.create(user, (err, result) => {
        expect(err).to.not.be.equal(null)
        expect(result).to.be.equal(null)
        done()
      })
    })

    it.skip('avoid creating an existing user', (done)=> {
      // TODO create this test
      // Warning: the user already exists
      const user = {
        username: "theotarbe"
      }
      userController.create(user, (err,result) => {
        expect(err).to.be.equal(null)
        expect(result).to.be.eql(null)
        done()
      })
    })
  })

  describe('Get', ()=> {
    // TODO Create test for the get method
    it.skip('successfully get a user by username', (done) => {
      // 1. First, create a user to make this unit test independent from the others
      const user = {
        username: 'theotarbe',
        firstname: 'theo',
        lastname: 'tarbe'
      }
      // 2. Then, check if the result of the get method is correct
      // userController.create(user, (err, result) => {
      //   expect(err).to.be.equal(null)
      //   expect(result).to.be.equal('OK')
      //   done()
      // })
      userController.get(user, (err, result) => {
        expect(err).to.be.equal(null)
        expect(result).to.eql(user)
        done()
      })
    })
  })
})
