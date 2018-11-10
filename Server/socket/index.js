const sqlInfo = require('../private/sqlinfo.json')
const Sequelize = require('sequelize')
const sequelize = new Sequelize(sqlInfo.database, sqlInfo.user, sqlInfo.password, {
  host: sqlInfo.host,
  dialect: "mysql",
  timezone: '+09:00'
})
/*
+----------+---------+------+-----+---------+----------------+
| Field    | Type    | Null | Key | Default | Extra          |
+----------+---------+------+-----+---------+----------------+
| Iid      | int(11) | NO   | PRI | NULL    | auto_increment |
| Aid      | int(11) | NO   | MUL | NULL    |                |
| Title    | text    | YES  |     | NULL    |                |
| Contents | text    | YES  |     | NULL    |                |
| Mid      | int(11) | NO   | MUL | NULL    |                |
+----------+---------+------+-----+---------+----------------+
 */
const User = sequelize.define('User', {
  Idx: { type: Sequelize.INTEGER, autoIncrement: true, primaryKey: true, allowNull: false },
  Id: { type: Sequelize.STRING(45), allowNull: false },
  Password: { type: Sequelize.STRING(60), allowNull: false },
  Name: { type: Sequelize.STRING(45), allowNull: false },
  IsBan: { type: Sequelize.STRING(5), allowNull: false, defaultValue: 'No' }
}, {
    timestamps: false,
    paranoid: true,
    underscored: true,
    freezeTableName: true,
    tableName: 'User'
  }
)

const Place = sequelize.define('Place', {
  Idx: { type: Sequelize.INTEGER, autoIncrement: true, allowNull: false, primaryKey: true },
  Name: { type: Sequelize.TEXT, allowNull: false},
  Explaination: { type: Sequelize.TEXT, allowNull: true }
}, {
  timestamps: false,
  paranoid: true,
  underscored: true,
  freezeTableName: true,
  tableName: 'Place'
})

const Message = sequelize.define('Message', {
  Idx: { type: Sequelize.INTEGER, autoIncrement: true, primaryKey: true },
  Place: { type: Sequelize.INTEGER, allowNull: false },
  User: { type: Sequelize.INTEGER, allowNull: false },
  Content: { type: Sequelize.TEXT, allowNull: true },
  UpTime: { type: Sequelize.DATE, defaultValue: Sequelize.NOW }
}, {
  timestamps: false,
  paranoid: true,
  underscored: true,
  freezeTableName: true,
  tableName: 'Message'
})
/**
 * Socket.io 라우팅
 * @param {SocketIO.Socket} client
 */
function Route(client) {
  console.log('Connect', client.id)
  client.on('screenMode', function (data) {
    client.join('screen' + data)
    Message.findAll({
      where: {
        Place: data
      }
    })
    .then(res => {
      client.emit('init', res)
    })
    .catch(err => {
      console.log(err)
      client.emit('init', false)
    })
  })
  client.on('login', function (data) {
    console.log(data)
    if (!(data && data.Id && data.Password))
      return client.emit('login_res', false)
    
    User.findOne({
      where: {
        Id: data.Id,
        Password: data.Password
      }
    })
    .then(res => {
      if (res)
      {
        client.isAuthed = true
        client.userId = res.Idx
        return client.emit('login_res', true)
      }
      client.emit('login_res', false)
    })
    .catch(error => {
      console.log(error)
      client.emit('login_res', false)
    })
  })
  client.on('join', function (data) {
    User.create({
      Id: data.Id,
      Password: data.Password,
      Name: data.Name
    })
    .then(() => {
      client.emit('join_res', true)
    })
    .catch(error => {
      console.log(error)
      client.emit('join_res', false)
    })
  })
  client.on('count', function () {
    User.count()
    .then(value => {
      client.emit('count_res', value)
    })
  })
  client.on('addplace', function (data) {
    if (!(data && data.Name && data.Explaination))
      return client.emit('addplace_res', false)
    Place.create({
      Name: data.Name,
      Explaination: data.Explaination
    })
    .then(res => {
      return client.emit('addplace_res', true)
    })
    .catch(err => {
      return client.emit('addplace_res', false)
    })
  })
  client.on('getplace', function () {
    Place.findAll()
    .then(res => {
      client.emit('getplace_res', res)
    })
  })
  client.on('addmessage', function (data) {
    if (!client.userId)
      client.emit('addmessage_res', false)
    if (!(data && data.Content && data.Place))
      client.emit('addmessage_res', false)
    Message.create({
      Content: data.Content,
      User: client.userId,
      Place: data.Place
    })
    .then(res => {
      console.log(res)
      client.emit('addmessage_res', true)
      client.to('screen' + data.Place).emit(res.dataValues)
    })
    .catch(err => {
      client.emit('addmessage_res', false)
    })
  })
  
}


module.exports = Route