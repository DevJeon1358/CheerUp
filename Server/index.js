const io = require('socket.io')(3030)
io.on('connection', require('./socket'))