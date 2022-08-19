/*
 * Project: Agenda Cultural Back End Net Core
 * Author: Luis Fernando Choque (luisfernandochoquea@gmail.com)
 * -----
 * Copyright 2021 - 2022 Universidad Privada Boliviana La Paz, Luis Fernando Choque Arana
 */
using log4net;
using System;

namespace Events.Domain
{
    public static class Logger
    {
        private static ILog Log { get; set; }

        static Logger() => Log = LogManager.GetLogger(typeof(Logger));

        public static void Error(object msg) => Log.Error(msg);

        public static void Error(object msg, Exception ex) => Log.Error(msg, ex);

        public static void Error(Exception ex) => Log.Error(ex.Message, ex);

        public static void Info(object msg) => Log.Info(msg);

        public static void Warn(object msg) => Log.Warn(msg);
    }
}
