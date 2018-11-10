var express = require('express');
const http = require('http')
var app = express();
app.use(function (req, res, next) {
  res.header("Access-Control-Allow-Origin", "*");
  res.header("Access-Control-Allow-Headers", "X-Requested-With");
  res.header("Access-Control-Allow-Headers", "Content-Type");
  res.header("Access-Control-Allow-Methods", "PUT, GET, POST, DELETE, OPTIONS");
  next();
});
app.get('/', (req, res) => {
  res.sendFile(__dirname+ '/test.html')
})
var server = http.createServer(app);

const io = require('socket.io').listen(server)
io.set('origins', '*:*')
io.on('connection', require('./socket'))

server.listen(80)