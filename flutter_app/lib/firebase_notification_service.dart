import 'package:firebase_messaging/firebase_messaging.dart';
import 'package:flutter_app/web_api_service.dart';

class FirebaseNotificationService {
  static FirebaseMessaging _firebaseMessaging;

  static Future<void> initiaize() async {
    _firebaseMessaging = FirebaseMessaging();

    _firebaseMessaging.configure(
      onMessage: _pushMessageHandler,
      onBackgroundMessage: _backgroundMessageHandler,
      onLaunch: _launchMessageHandler,
      onResume: _resumeMessageHandler,
    );

    final fcmToken = await _firebaseMessaging.getToken();

    await WebApiService.registerDevice(fcmToken);

    _firebaseMessaging.onTokenRefresh.listen(_refreshTokenHandler);
  }

  static Future<String> getToken() async {
    return await _firebaseMessaging.getToken();
  }

  static Future<dynamic> _pushMessageHandler(Map<String, dynamic> message) async {
    print('onMessage: $message');
  }

  // should be a STATIC or TOP-LEVEL
  static Future<dynamic> _backgroundMessageHandler(Map<String, dynamic> message) async {
    print('onBackgroundMessage: $message');
  }

  static Future<dynamic> _launchMessageHandler(Map<String, dynamic> message) async {
    print('onLaunch: $message');
  }

  static Future<dynamic> _resumeMessageHandler(Map<String, dynamic> message) async {
    print('onResume: $message');
  }

  static Future<dynamic> _refreshTokenHandler(String newToken) async {
    print("newToken: $newToken");
  }
}
