const firebaseApp = require("../lib/firebaseApp");


const userProcessor = async (req, res, next) => {
    try {
        const bearerHeader = req.headers["authorization"];

        if (bearerHeader === undefined) {
            req.userInfo = null;
            next();
            return;
        }
        const token = bearerHeader.split(" ")[1];

        const decodedToken = await firebaseApp.auth().verifyIdToken(token);

        req.userInfo = decodedToken;
        next();
    } catch (err) {
        req.userInfo = null;
        next();
        return;
    }
}

module.exports = userProcessor;