import 'dart:io';
import 'package:dio/dio.dart';

class WebApiService {
  // localhost
  static String _apiUrl = 'http://10.0.2.2:5000/api/';

  static Future<void> registerDevice(String fcmToken) async {
    final url = _apiUrl + 'messaging/register-device';

    await Dio().post(
      url,
      options: RequestOptions(contentType: ContentType.json.toString()),
      data: {
        'fcmToken': fcmToken,
        'platform': Platform.operatingSystem,
      },
    ).then((response) {
      print('response status: ${response.statusCode}');
      print('response data: ${response.data}');
    }).catchError((error) {
      print(error);
    });
  }

  static Future<void> sendDeviceSpecificMessage({String fcmToken, String title, String body}) async {
    final url = _apiUrl + 'messaging/send-device-specific-message';

    await Dio().post(
      url,
      options: RequestOptions(contentType: ContentType.json.toString()),
      data: {
        'fcmToken': fcmToken,
        'title': title,
        'body': body,
      },
    ).then((response) {
      print('response status: ${response.statusCode}');
      print('response data: ${response.data}');
    }).catchError((error) {
      print(error);
    });
  }

  static Future<void> sendTopicMessage({String topic, String title, String body}) async {
    final url = _apiUrl + 'messaging/send-topic-message';

    await Dio().post(
      url,
      options: RequestOptions(contentType: ContentType.json.toString()),
      data: {
        'topic': topic,
        'title': title,
        'body': body,
      },
    ).then((response) {
      print('response status: ${response.statusCode}');
      print('response data: ${response.data}');
    }).catchError((error) {
      print(error);
    });
  }
}
