import base64

with open('bundle', 'rb') as file:
    # Read the contents of the file
    file_contents = file.read()

encoded_bytes = base64.b64encode(file_contents)

encoded_str = encoded_bytes.decode('utf-8')

with open('encodedbundle.txt', 'w') as encoded_file:
    encoded_file.write(encoded_str)

decoded_bytes = base64.b64decode(encoded_str)

with open('decodedbundle', 'wb') as decoded_file:
    decoded_file.write(decoded_bytes)