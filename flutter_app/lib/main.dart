import 'package:flutter/material.dart';
import 'package:flutter_app/firebase_notification_service.dart';
import 'package:flutter_app/web_api_service.dart';

void main() async {
  WidgetsFlutterBinding.ensureInitialized();
  
  FirebaseNotificationService.initiaize();

  runApp(MyApp());
}

class MyApp extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Flutter Demo',
      theme: ThemeData(
        primarySwatch: Colors.blue,
      ),
      home: Scaffold(
        appBar: AppBar(
          title: Text('Flutter Demo Home Page'),
        ),
        body: Center(
          child: FlatButton(
            color: Colors.blue,
            textColor: Colors.white,
            splashColor: Colors.blueAccent,
            padding: EdgeInsets.all(10.0),
            onPressed: () async {
              final fcmToken = await FirebaseNotificationService.getToken();

              WebApiService.sendDeviceSpecificMessage(
                fcmToken: fcmToken,
                title: 'Hello!',
                body: 'This is a push message',
              );
            },
            child: Text(
              'Send notification',
              style: TextStyle(fontSize: 20.0),
            ),
          ),
        ),
      ),
    );
  }
}
