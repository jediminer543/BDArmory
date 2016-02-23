using UnityEngine;
using System;
using System.Collections.Generic;


namespace BahaTurret
{
    [KSPAddon(KSPAddon.Startup.Instantly, true)]
    public class HitManager : MonoBehaviour
    {
        //Hook Registry
        private static readonly List<Action<Part>> hitHooks = new List<Action<Part>>();
        private static readonly List<Action<List<Part>>> multiHitHooks = new List<Action<List<Part>>>();
        private static readonly List<Action<ExplosionObject>> explosionHooks = new List<Action<ExplosionObject>>();
        private static readonly List<Action<BulletObject>> bulletHooks = new List<Action<BulletObject>>();
        private static readonly List<Action<InitTracerObject>> tracerInitHooks = new List<Action<InitTracerObject>>();
        private static readonly List<Action<UpdateTracerObject>> tracerHooks = new List<Action<UpdateTracerObject>>();
        private static readonly List<Action<Guid>> tracerDestroyHooks = new List<Action<Guid>>();
        private static readonly List<Action<Quaternion, Guid, uint>> turretYawHooks = new List<Action<Quaternion, Guid, uint>>();
        private static readonly List<Action<Quaternion, Guid, uint>> turretPitchHooks = new List<Action<Quaternion, Guid, uint>>();
        private static readonly List<Action<bool, Guid, uint>> turretDeployHooks = new List<Action<bool, Guid, uint>>();
        private static readonly List<Action<Vector3, Vector3, Guid, uint>> laserHooks = new List<Action<Vector3, Vector3, Guid, uint>>();
        private static readonly List<Action<FlareObject>> flareHooks = new List<Action<FlareObject>>();
        private static readonly List<Func<Guid, bool>> allowDamageHooks = new List<Func<Guid, bool>>();
        private static readonly List<Func<bool>> allowControlHooks = new List<Func<bool>>();

        public HitManager()
        {

        }

        public static void RegisterHitHook(Action<Part> hitHook)
        {
            if (!hitHooks.Contains(hitHook))
            {
                hitHooks.Add(hitHook);
            }
        }

        public static void RegisterMultiHitHook(Action<List<Part>> hitHook)
        {
            if (!multiHitHooks.Contains(hitHook))
            {
                multiHitHooks.Add(hitHook);
            }
        }

        public static void RegisterExplosionHook(Action<ExplosionObject> explosionHook)
        {
            if (!explosionHooks.Contains(explosionHook))
            {
                explosionHooks.Add(explosionHook);
            }
        }

        public static void RegisterBulletHook(Action<BulletObject> bulletHook)
        {
            if (!bulletHooks.Contains(bulletHook))
            {
                bulletHooks.Add(bulletHook);
            }
        }

        public static void RegisterTracerInitHook(Action<InitTracerObject> tracerInitHook)
        {
            if (!tracerInitHooks.Contains(tracerInitHook))
            {
                tracerInitHooks.Add(tracerInitHook);
            }
        }

        public static void RegisterTracerHook(Action<UpdateTracerObject> tracerHook)
        {
            if (!tracerHooks.Contains(tracerHook))
            {
                tracerHooks.Add(tracerHook);
            }
        }

        public static void RegisterTracerDestroyHook(Action<Guid> tracerDestroyHook)
        {
            if (!tracerDestroyHooks.Contains(tracerDestroyHook))
            {
                tracerDestroyHooks.Add(tracerDestroyHook);
            }
        }

        public static void RegisterAllowDamageHook(System.Func<Guid, bool> allowDamageHook)
        {
            if (!allowDamageHooks.Contains(allowDamageHook))
            {
                allowDamageHooks.Add(allowDamageHook);
            }
        }

        public static void RegisterAllowControlHook(System.Func<bool> allowControlHook)
        {
            if (!allowControlHooks.Contains(allowControlHook))
            {
                allowControlHooks.Add(allowControlHook);
            }
        }

        public static void RegisterTurretPitchHook(Action<Quaternion, Guid, uint> turretPitchHook)
        {
            if (!turretPitchHooks.Contains(turretPitchHook))
            {
                turretPitchHooks.Add(turretPitchHook);
            }
        }

        public static void RegisterTurretYawHook(Action<Quaternion, Guid, uint> turretYawHook)
        {
            if (!turretYawHooks.Contains(turretYawHook))
            {
                turretYawHooks.Add(turretYawHook);
            }
        }

        public static void RegisterLaserHook(Action<Vector3, Vector3, Guid, uint> laserHook)
        {
            if (!laserHooks.Contains(laserHook))
            {
                laserHooks.Add(laserHook);
            }
        }

        public static void RegisterFlareHook(Action<FlareObject> flareHook)
        {
            if (!flareHooks.Contains(flareHook))
            {
                flareHooks.Add(flareHook);
            }
        }

        public static void RegisterTurretDeployHook(Action<bool, Guid, uint> turretDeployHook)
        {
            if (!turretDeployHooks.Contains(turretDeployHook))
            {
                turretDeployHooks.Add(turretDeployHook);
            }
        }

        public static void FireHitHooks(Part hitPart)
        {
            //Fire hitHooks
            foreach (Action<Part> hitHook in hitHooks)
            {
                hitHook(hitPart);
            }
        }

        public static void FireMultiHitHooks(List<Part> hitParts)
        {
            //Fire hitHooks
            foreach (Action<List<Part>> multiHitHook in multiHitHooks)
            {
                multiHitHook(hitParts);
            }
        }

        public static void FireExplosionHooks(ExplosionObject explosion)
        {
            foreach (Action<ExplosionObject> explosionHook in explosionHooks)
            {
                explosionHook(explosion);
            }
        }

        public static void FireBulletHooks(BulletObject bullet)
        {
            foreach (Action<BulletObject> bulletHook in bulletHooks)
            {
                bulletHook(bullet);
            }
        }

        public static void FireTracerInitHooks(InitTracerObject tracer)
        {
            foreach (Action<InitTracerObject> tracerInitHook in tracerInitHooks)
            {
                tracerInitHook(tracer);
            }
        }

        public static void FireTracerHooks(UpdateTracerObject tracer)
        {
            foreach (Action<UpdateTracerObject> tracerHook in tracerHooks)
            {
                tracerHook(tracer);
            }
        }

        public static void FireTracerDestroyHooks(Guid tracer)
        {
            foreach (Action<Guid> tracerHook in tracerDestroyHooks)
            {
                tracerHook(tracer);
            }
        }

        public static void FireTurretYawHook(Quaternion rotation, Guid vesselID, uint turretID)
        {
            foreach (Action<Quaternion, Guid, uint> yawHook in turretYawHooks)
            {
                yawHook(rotation, vesselID, turretID);
            }
        }

        public static void FireTurretPitchHook(Quaternion rotation, Guid vesselID, uint turretID)
        {
            foreach (Action<Quaternion, Guid, uint> pitchHook in turretPitchHooks)
            {
                pitchHook(rotation, vesselID, turretID);
            }
        }

        public static void FireLaserHooks(Vector3 p1, Vector3 p2, Guid vesselID, uint turretID)
        {
            foreach (Action<Vector3, Vector3, Guid, uint> laserHook in laserHooks)
            {
                laserHook(p1, p2, vesselID, turretID);
            }
        }

        public static void FireFlareHooks(FlareObject flare)
        {
            foreach (Action<FlareObject> flareHook in flareHooks)
            {
                flareHook(flare);
            }
        }

        public static void FireTurretDeployHooks(bool state, Guid vessel, uint turret)
        {
            foreach (Action<bool, Guid, uint> turretDeployHook in turretDeployHooks)
            {
                turretDeployHook(state, vessel, turret);
            }
        }

        public static bool ShouldAllowDamageHooks(Guid vesselID)
        {
            foreach (Func<Guid, bool> allowDamageHook in allowDamageHooks)
            {
                bool result;
                result = allowDamageHook(vesselID);
                if (!result)
                {
                    return false;
                }
            }
            return true;
        }

        public static bool ShouldAllowControl()
        {
            foreach (Func<bool> allowControlHook in allowControlHooks)
            {
                bool result;
                result = allowControlHook();
                if (!result)
                {
                    return false;
                }
            }
            return true;
        }
    }

    public class ExplosionObject
    {
        public readonly Vector3 position;
        public readonly float raduis;
        public readonly float power;
        public readonly Vessel sourceVessel;
        public readonly Vector3 direction;
        public readonly string explModelPath;
        public readonly string soundPath;

        public ExplosionObject(Vector3 positionVal, float radiusVal, float powerVal, Vessel sourceVesselVal, Vector3 directionVal, string explModelPathVal, string soundPathVal)
        {
            position = positionVal;
            raduis = radiusVal;
            power = powerVal;
            sourceVessel = sourceVesselVal;
            direction = directionVal;
            explModelPath = explModelPathVal;
            soundPath = soundPathVal;
        }

    }

    public class BulletObject
    {
        public readonly Vector3 position;
        public readonly Vector3 normalDirection;
        public readonly bool ricochet;

        public BulletObject(Vector3 positionVal, Vector3 normalDirectionVal, bool ricochetVal)
        {
            position = positionVal;
            normalDirection = normalDirectionVal;
            ricochet = ricochetVal;
        }
    }

    public class InitTracerObject
    {
        public readonly Guid tracerID, vesselID;
        public readonly uint turretID;
        public readonly string bulletTexPath;

        public InitTracerObject(string bulletTexPath, Guid tracerID, Guid vesselID, uint turretID)
        {
            this.bulletTexPath = bulletTexPath;
            this.tracerID = tracerID;
            this.turretID = turretID;
            this.vesselID = vesselID;
        }
    }

    public class UpdateTracerObject
    {
        public readonly Vector3 p1;
        public readonly Vector3 p2;
        public readonly Color color;
        public readonly float width1, width2;
        public readonly Guid tracerID;

        public UpdateTracerObject(Vector3 p1, Vector3 p2, Color newColor, float width1, float width2, Guid tracerID)
        {
            this.p1 = p1;
            this.p2 = p2;
            this.color = newColor;
            this.width1 = width1;
            this.width2 = width2;
            this.tracerID = tracerID;
        }
    }

    public class FlareObject
    {
        public readonly Vector3 pos;
        public readonly Vector3 vel;
        public readonly Quaternion rot;
        public readonly Guid sourceVessel;

        public FlareObject(Vector3 pos, Quaternion rot, Vector3 vel, Guid sourceVessel)
        {
            this.pos = pos;
            this.vel = vel;
            this.rot = rot;
            this.sourceVessel = sourceVessel;

        }
    }
}

