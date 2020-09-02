# Dotnet-Flutter Firebase Cloud Messaging Integration Demo

- Flutter version: v1.12.13+hotfix.9
- Firebase Cloud Messaging for Flutter plugin version: 7.0.0
- .NET Admin SDK version: 1.15.0

### How to run the demo
1. Using the Firebase Console add an Android app to your project: Follow the assistant, download the generated google-services.json file and place it inside android/app.
2. [Generate a private key file to access Firebase services and set the environment variable GOOGLE_APPLICATION_CREDENTIALS](https://firebase.google.com/docs/admin/setup#initialize-sdk).

### Integration guide
1. Integrate the [Firebase Cloud Messaging for Flutter](https://pub.dev/packages/firebase_messaging) plugin according to the [guide](https://pub.dev/packages/firebase_messaging#getting-started).
2. Fix the Application.java file if you got an error "incompatible types: PluginRegistry cannot be converted to FlutterEngine":
   ```
   Replace this code line:

   GeneratedPluginRegistrant.registerWith(registry);
   with this:

   FirebaseMessagingPlugin.registerWith(registry.registrarFor("io.flutter.plugins.firebasemessaging.FirebaseMessagingPlugin"));
   Make sure to import:

   import io.flutter.plugins.firebasemessaging.FirebaseMessagingPlugin;
   ```
3. Add the Firebase Admin SDK to your server according to the [guide](https://firebase.google.com/docs/admin/setup).