# Generated by Django 3.2.7 on 2021-10-01 16:27

from django.db import migrations, models


class Migration(migrations.Migration):

    initial = True

    dependencies = [
    ]

    operations = [
        migrations.CreateModel(
            name='Shop',
            fields=[
                ('lastupdate', models.DateTimeField(auto_now_add=True, primary_key=True, serialize=False)),
                ('item1', models.IntegerField(default=0)),
                ('item2', models.IntegerField(default=0)),
                ('item3', models.IntegerField(default=0)),
            ],
        ),
    ]
