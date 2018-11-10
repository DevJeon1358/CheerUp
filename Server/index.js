const io = require('socket.io')(80)
io.on('connection', require('./socket'))